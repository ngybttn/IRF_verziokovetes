﻿using gyak06_eu810u.Entities;
using gyak06_eu810u.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace gyak06_eu810u
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();
            var r = GetExchangeRates();
            GetXmlData(r);
            mnbdataGridView.DataSource = Rates;
        }

        private string GetExchangeRates()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"

            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            return result;

        }


        private void GetXmlData(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement item in xml.DocumentElement)
            {
                var date = item.GetAttribute("date");

                var rate = (XmlElement)item.ChildNodes[0];
                var currency = rate.GetAttribute("curr");
                var value = rate.InnerText;

                Rates.Add(new RateData()
                { Date = DateTime.Parse(date),
                  Currency = currency,
                  Value = decimal.Parse(value)});

                
            }
        }
    }
}

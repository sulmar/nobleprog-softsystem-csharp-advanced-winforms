using LabelTech.Sdk;
using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lims.Infrastucture
{
    // Wzorzec Projektowy Adapter (wariant obiektowy)
    public class LabelTechLabelPrinter : ILabelPrinter
    {
        private readonly string port;

        public LabelTechLabelPrinter(string port)
        {
            this.port = port;
        }

        public void Print(Sample sample)
        {
            // Adaptee
            var printer = new LabelTechPrinter();

            printer.Connect(port);            

            SampleLabelFluentBuilder builder = new SampleLabelFluentBuilder(sample)
                .WithHeader("LABORATORIUM")
                .WithPatient()
                .WithAnalyte();

            if (sample.Priority > Priority.Normal)
            {
                builder.WithPriority();
            }

            SampleLabel label = builder.Build();

            string content = label.Text;

            printer.PrintLine(content);

            printer.Disconnect();

        }
    }

    // Product
    public class SampleLabel
    {
        public string Text { get; }

        public SampleLabel(string text)
        {
            Text = text;
        }        
    }

    public class SampleLabelBuilder
    {
        private readonly Sample sample;

        private readonly List<string> _lines = new List<string>();

        public SampleLabelBuilder(Sample sample)
        {
            this.sample = sample;
        }

        public void WithHeader(string header)
        {
            _lines.Add(header);
        }

        public void WithPatient()
        {
            _lines.Add($"PESEL: {sample.Pesel}");
        }

        public void WithAnalyte()
        {
            _lines.Add($"Badanie: {sample.Analyte}");
        }

        public void WithPrice()
        {
            var culture = CultureInfo.GetCultureInfo("pl-PL");
            _lines.Add($"Cena: {sample.Price.ToString("C2", culture)}");
        }


        public void WithPriority()
        {
            _lines.Add($"Priorytet: {sample.Priority}");
        }

        public SampleLabel Build()
        {
            if (_lines.Count == 0)
            {
                throw new InvalidOperationException("Etykieta jest pusta");
            }

            return new SampleLabel(string.Join(Environment.NewLine, _lines));
        }
    }

    public class SampleLabelFluentBuilder
    {
        private readonly Sample sample;

        private readonly List<string> _lines = new List<string>();

        public SampleLabelFluentBuilder(Sample sample)
        {
            this.sample = sample;
        }

        public SampleLabelFluentBuilder WithHeader(string header)
        {
            _lines.Add(header);

            return this;
        }

        public SampleLabelFluentBuilder WithPatient()
        {
            _lines.Add($"PESEL: {sample.Pesel}");

            return this;
        }

        public SampleLabelFluentBuilder WithAnalyte()
        {
            _lines.Add($"Badanie: {sample.Analyte}");

            return this;
        }

        public SampleLabelFluentBuilder WithPrice()
        {
            var culture = CultureInfo.GetCultureInfo("pl-PL");
            _lines.Add($"Cena: {sample.Price.ToString("C2", culture)}");


            return this;
        }


        public SampleLabelFluentBuilder WithPriority()
        {
            _lines.Add($"Priorytet: {sample.Priority}");

            return this;
        }

        public SampleLabel Build()
        {
            if (_lines.Count == 0)
            {
                throw new InvalidOperationException("Etykieta jest pusta");
            }

            return new SampleLabel(string.Join(Environment.NewLine, _lines));
        }
    }
}

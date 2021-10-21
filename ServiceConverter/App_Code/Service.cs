using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service" nel codice, nel file svc e nel file di configurazione contemporaneamente.
public class Service : IService
{
	public List<Valuta> Valute = new List<Valuta>();
	Dictionary<string, double> Cambio = new Dictionary<string, double>();
	public Service()
    {
		Valute.Add(new Valuta("EUR", "Euro"));
		Valute.Add(new Valuta("USD", "Dollari Americani"));
		Valute.Add(new Valuta("GBP", "Sterlina Inglese"));
		Valute.Add(new Valuta("JPY", "Yen Giapponese"));
		Valute.Add(new Valuta("CHF", "Franco Svizzero"));
		Valute.Add(new Valuta("CAD", "Dollari Canadese"));
		Valute.Add(new Valuta("AUD", "Dollaro Australiano"));
		Valute.Add(new Valuta("BTC", "Bitcoin"));
		Cambio.Add("EUR", 1);
		Cambio.Add("USD", 1.1655);
		Cambio.Add("GBP", 0.8427);
		Cambio.Add("JPY", 133.12);
		Cambio.Add("CHF", 1.0710);
		Cambio.Add("CAD", 1.4357);
		Cambio.Add("AUD", 1.5495);
		Cambio.Add("BTC", 0.000018);
	}
	

	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	public List<Valuta> getValute()
    {
		return Valute;
    }

	public double converti(double importo, string da, string a)
	{
		double valore;
		valore = importo / Cambio[da];
		valore = valore * Cambio[a];
		return valore;
    }

}

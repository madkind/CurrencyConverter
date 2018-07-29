
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
using System.ComponentModel.DataAnnotations;
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gesmes.org/xml/2002-08-01")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gesmes.org/xml/2002-08-01", IsNullable = false)]
public partial class Envelope
{

    private string subjectField;

    private EnvelopeSender senderField;

    private CubeCube[] cubeField;

    /// <remarks/>
    public string subject
    {
        get
        {
            return this.subjectField;
        }
        set
        {
            this.subjectField = value;
        }
    }

    /// <remarks/>
    public EnvelopeSender Sender
    {
        get
        {
            return this.senderField;
        }
        set
        {
            this.senderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Cube", IsNullable = false)]
    public CubeCube[] Cube
    {
        get
        {
            return this.cubeField;
        }
        set
        {
            this.cubeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gesmes.org/xml/2002-08-01")]
public partial class EnvelopeSender
{

    private string nameField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
public partial class CubeCube
{

    private CubeCubeCube[] cubeField;

    private System.DateTime timeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Cube")]
    public CubeCubeCube[] Cube
    {
        get
        {
            return this.cubeField;
        }
        set
        {
            this.cubeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime time
    {
        get
        {
            return this.timeField;
        }
        set
        {
            this.timeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
public partial class CubeCubeCube
{

    private string currencyField;

    private decimal rateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currency
    {
        get
        {
            return this.currencyField;
        }
        set
        {
            this.currencyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref", IsNullable = false)]
public partial class Cube
{

    private CubeCube[] cube1Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Cube")]
    public CubeCube[] Cube1
    {
        get
        {
            return this.cube1Field;
        }
        set
        {
            this.cube1Field = value;
        }
    }
}

public class ExchangeRate
{
    public string Currency { get; set; }
    public decimal Rate { get; set; }
    public System.DateTime Time { get; set; }
}

public class ExchangeQueryModel {
    [Required]
    public string CurrencyFrom { get; set; }
    [Required]
    public string CurrencyTo { get; set; }
    [Required]
    public decimal Amount { get; set; }
}
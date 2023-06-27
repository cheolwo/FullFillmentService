using System.Xml.Serialization;

HttpClient client = new HttpClient();
string url = "http://apis.data.go.kr/1613000/AptBasisInfoService1/getAphusBassInfo"; // URL
url += "?ServiceKey=" + ""; // Service Key
url += "&kaptCode=A10027875";


var r = await client.GetAsync(url);

string xmlString = await r.Content.ReadAsStringAsync();


XmlSerializer serializer = new XmlSerializer(typeof(Response));
using (TextReader reader = new StringReader(xmlString))
{
Response result = (Response)serializer.Deserialize(reader);
var itemType = result.body.item.GetType();
foreach (var property in itemType.GetProperties())
{
Console.WriteLine("{0}: {1}", property.Name, property.GetValue(result.body.item));
}

}

[Serializable]
[XmlRoot("response")]
public class Response
{
    public Header header { get; set; }
    public Body body { get; set; }
}

public class Header
{
    public string resultCode { get; set; }
    public string resultMsg { get; set; }
}

public class Body
{
    public Item item { get; set; }
}

public class Item
{
    public string bjdCode { get; set; }
    public string codeAptNm { get; set; }
    public string codeHallNm { get; set; }
    public string codeHeatNm { get; set; }
    public string codeMgrNm { get; set; }
    public string codeSaleNm { get; set; }
    public string doroJuso { get; set; }
    public int hoCnt { get; set; }
    public string kaptAcompany { get; set; }
    public string kaptAddr { get; set; }
    public string kaptBcompany { get; set; }
    public string kaptCode { get; set; }
    public int kaptDongCnt { get; set; }
    public string kaptFax { get; set; }
    public double kaptMarea { get; set; }
    public int kaptMparea_135 { get; set; }
    public int kaptMparea_136 { get; set; }
    public int kaptMparea_60 { get; set; }
    public int kaptMparea_85 { get; set; }
    public string kaptName { get; set; }
    public double kaptTarea { get; set; }
    public string kaptTel { get; set; }
    public string kaptUrl { get; set; }
    public string kaptUsedate { get; set; }
    public int kaptdaCnt { get; set; }
    public double privArea { get; set; }
}
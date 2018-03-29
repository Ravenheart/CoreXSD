using System;
using System.IO;
using System.Xml.Serialization;

namespace CoreXSD
{
    class Program
    {
        static void Main(string[] args)
        {
            cpFile cp = new cpFile();
            Protocol_DrugTherapy therapy = new Protocol_DrugTherapy();
            therapy.Part_Chemotherapy = new Protocol_DrugTherapyPart_Chemotherapy();
            therapy.Part_Chemotherapy.Gen_Markers = new Protocol_DrugTherapyPart_ChemotherapyGen_Markers();
            therapy.Part_Chemotherapy.Gen_Markers.Name = new string[2] { "One", "Two" };
            therapy.Part_Chemotherapy.Gen_Markers.Sign = new bool[2] { true, false };
            cp.Protocol_DrugTherapy = new Protocol_DrugTherapy[1] { therapy };

            using (var output = new FileStream("output.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(cpFile)); 
                xml.Serialize(output, cp);
                output.Flush();
            }
        }
    }
}

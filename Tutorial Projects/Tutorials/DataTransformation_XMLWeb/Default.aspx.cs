using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace DataTransformation_XMLWeb
{
    public partial class _Default : Page
    {
        //private const string Uri = "XSLTClient/StudentsXML.xml";
        private const string Uri = "C:/Projects/Tutorial Projects/Tutorials/DataTransformation_XMLWeb/XSLTClient/StudentsXML.xml";

        protected void Page_Load(object sender, EventArgs e)
        {

            XDocument xDocument = XDocument.Load(Uri);
            var oAll = xDocument.Descendants("Student").ToList();
                        
            var o = xDocument.Descendants("Student").Select(x =>
              new
              {
                  id = x.Attribute("Id").Value,
                  name = x.Element("Name").Value
              }).ToList();

            var o2 = (from x in o
                      select new StudentModel
                      {
                          Id = Convert.ToInt32(x.id),
                          Name = x.name
                      }).ToList();

            List<StudentModel> smodel = (from x in o
                      select new StudentModel
                      {
                          Id = Convert.ToInt32(x.id),
                          Name = x.name
                      }).ToList();

            //Console.ReadLine();
        }

        [WebMethod]
        public static string GetTime()
        {
            return "Hi";
        }

        class StudentModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }


}
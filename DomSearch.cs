using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Maui_Lab2
{
    internal class DomSearch: ISearch
    {
        public List<Material> Search(Material material, string path)
        {
            List<Material> searchResult = new List<Material>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNode node = xmlDoc.DocumentElement;
            foreach (XmlNode _node in node.ChildNodes)
            {
                string AuthorName = "";
                string Name = "";
                string Faculty = "";
                string Department = "";
                string Type = "";
                string CreationDate = "";

                foreach (XmlAttribute attribute in _node.Attributes)
                {
                    if (attribute.Name.Equals("AuthorName") && (attribute.Value == material?.AuthorName || String.IsNullOrEmpty(material?.AuthorName)))
                    {
                        AuthorName = attribute.Value;
                    }


                    if (attribute.Name.Equals("Name") && (attribute.Value == material?.Name || String.IsNullOrEmpty(material?.Name)))
                    {
                        Name = attribute.Value;
                    }

                    if (attribute.Name.Equals("Faculty") && (attribute.Value == material?.Faculty || String.IsNullOrEmpty(material?.Faculty)))
                    {
                        Faculty = attribute.Value;
                    }

                    if (attribute.Name.Equals("Department") && (attribute.Value == material?.Department || String.IsNullOrEmpty(material?.Department)))
                    {
                        Department = attribute.Value;
                    }

                    if (attribute.Name.Equals("Type") && (attribute.Value == material?.Type || String.IsNullOrEmpty(material?.Type)))
                    {
                        Type = attribute.Value;
                    }

                    if (attribute.Name.Equals("CreationDate") && (attribute.Value == material?.CreationDate || String.IsNullOrEmpty(material?.CreationDate)))
                    {
                        CreationDate = attribute.Value;
                    }

                }

                if (AuthorName != "" && Name != "" && Faculty != "" && Department != "" && Type != "" && CreationDate != "")
                {
                    Material myMaterial = new Material();
                    myMaterial.AuthorName = AuthorName;
                    myMaterial.Name = Name;
                    myMaterial.Faculty = Faculty;
                    myMaterial.Department = Department;
                    myMaterial.Type = Type;
                    myMaterial.CreationDate = CreationDate;

                    searchResult.Add(myMaterial);
                }
            }
            return searchResult;
        }
    }
}

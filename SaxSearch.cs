using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Maui_Lab2
{
    internal class SaxSearch: ISearch
    {
        public List<Material> Search(Material material, string path)
        {
            List<Material> result = new List<Material>();
            using (XmlReader xmlReader = XmlReader.Create(path))
            {
                Material currentMaterial = null;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Material")
                    {
                        currentMaterial = new Material();
                        ReadAttributes(xmlReader, currentMaterial, material);

                        if (MaterialMatchesSearchCriteria(currentMaterial, material))
                        {
                            result.Add(currentMaterial);
                        }
                    }
                }
            }

            return result;
        }

        private void ReadAttributes(XmlReader xmlReader, Material currentMaterial, Material searchCriteria)
        {
            if (xmlReader.HasAttributes)
            {
                while (xmlReader.MoveToNextAttribute())
                {
                    string attributeName = xmlReader.Name;
                    string attributeValue = xmlReader.Value;

                    switch (attributeName)
                    {
                        case "AuthorName":
                            currentMaterial.AuthorName = attributeValue;
                            break;

                        case "Name":
                            currentMaterial.Name = attributeValue;
                            break;

                        case "Faculty":
                            currentMaterial.Faculty = attributeValue;
                            break;

                        case "Department":
                            currentMaterial.Department = attributeValue;
                            break;

                        case "Type":
                            currentMaterial.Type = attributeValue;
                            break;

                        case "CreationDate":
                            currentMaterial.CreationDate = attributeValue;
                            break;
                    }
                }
            }
        }

        private bool MaterialMatchesSearchCriteria(Material material, Material searchCriteria)
        {
            return (string.IsNullOrEmpty(searchCriteria?.AuthorName) || material.AuthorName.Equals(searchCriteria.AuthorName, StringComparison.OrdinalIgnoreCase))
                && (string.IsNullOrEmpty(searchCriteria?.Name) || material.Name.Equals(searchCriteria.Name, StringComparison.OrdinalIgnoreCase))
                && (string.IsNullOrEmpty(searchCriteria?.Faculty) || material.Faculty.Equals(searchCriteria.Faculty, StringComparison.OrdinalIgnoreCase))
                && (string.IsNullOrEmpty(searchCriteria?.Department) || material.Department.Equals(searchCriteria.Department, StringComparison.OrdinalIgnoreCase))
                && (string.IsNullOrEmpty(searchCriteria?.Type) || material.Type.Equals(searchCriteria.Type, StringComparison.OrdinalIgnoreCase))
                && (string.IsNullOrEmpty(searchCriteria?.CreationDate) || material.CreationDate.Equals(searchCriteria.CreationDate, StringComparison.OrdinalIgnoreCase));
        }
    }
}

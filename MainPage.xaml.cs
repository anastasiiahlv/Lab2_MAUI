using Microsoft.Maui.Controls.Shapes;
using System.Xml;
using System.Xml.Xsl;


namespace Maui_Lab2;

public partial class MainPage : ContentPage
{
    string xmlpath = "C:\\Users\\USER\\Desktop\\Maui_Lab2\\XMLFile1.xml";
    public List<string> authorNameComboBox { get; set; }
    public List<string> nameComboBox { get; set;  } 
    public List<string> facultyComboBox { get; set; }
    public List<string> departmentComboBox { get; set; }
    public List<string> typeComboBox { get; set; }
    public List<string> creationDateComboBox { get; set; }

    public Material FilterMaterial { get; set; }

    public MainPage()
	{
        Material FilterMaterial = new Material();
        LinqSearch linq = new LinqSearch();
        var materials = linq.Search(FilterMaterial, xmlpath);
        authorNameComboBox = new List<string>(materials.Select(obj => obj.AuthorName).Distinct().ToList());
        nameComboBox = new List<string>(materials.Select(obj => obj.Name).Distinct().ToList());
        facultyComboBox = new List<string>(materials.Select(obj => obj.Faculty).Distinct().ToList());
        departmentComboBox = new List<string>(materials.Select(obj => obj.Department).Distinct().ToList());
        typeComboBox = new List<string>(materials.Select(obj => obj.Type).Distinct().ToList());
        creationDateComboBox = new List<string>(materials.Select(obj => obj.CreationDate).Distinct().ToList());

        BindingContext = this;
        InitializeComponent();

        ToolbarItems.Add(new ToolbarItem("Exit", null, async () =>
        {
            bool answer = await DisplayAlert("Exit", "Are you sure you want to leave the programme?", "Yes", "No");

            if (answer)
            {
                Application.Current.Quit();
            }
        }));
    }

    public void SearchButton_Clicked(object sender, EventArgs e)
    {
        searchMaterials();
    }

    public void searchMaterials()
    {
        Material material = new Material();

        if(authorNameSelect.SelectedItem != null)
            material.AuthorName = authorNameSelect.SelectedItem?.ToString();

        if (nameSelect.SelectedItem != null)
            material.Name = nameSelect.SelectedItem?.ToString();

        if(facultySelect.SelectedItem != null)
            material.Faculty = facultySelect.SelectedItem?.ToString();

        if(departmentSelect.SelectedItem != null)
            material.Department = departmentSelect.SelectedItem?.ToString();

        if(typeSelect.SelectedItem != null)
            material.Type = typeSelect.SelectedItem?.ToString();

        if (creationDateSelect.SelectedItem != null)
            material.CreationDate = creationDateSelect.SelectedItem?.ToString();

        ISearch searchMethod = new LinqSearch();

        if (DOMButton.IsChecked)
            searchMethod = new DomSearch();
        if (SAXButton.IsChecked)
            searchMethod = new SaxSearch();
        if (LINQButton.IsChecked)
            searchMethod = new LinqSearch();

        List<Material> materials = searchMethod.Search(material, xmlpath);

        MaterialCollectionView.ItemsSource = materials;
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        FilterMaterial = new Material();

        authorNameSelect.SelectedItem = null;
        nameSelect.SelectedItem = null;
        facultySelect.SelectedItem = null;
        departmentSelect.SelectedItem = null;
        typeSelect.SelectedItem = null;
        creationDateSelect.SelectedItem = null;

        MaterialCollectionView.ItemsSource = null;
    }

    private async void SaveHTMLButton_Clicked(object sender, EventArgs e)
    {
        XslCompiledTransform xslt = new XslCompiledTransform();

        string xsl = "C:\\Users\\USER\\Desktop\\Maui_Lab2\\XSLFile.xsl";

        xslt.Load(xsl);
        
        string outputPath = "C:\\Users\\USER\\Desktop\\Maui_Lab2\\Saved HTML";
        
        string result = System.IO.Path.Combine(outputPath, @"HtmlResult.html");

        xslt.Transform(xmlpath, result);

        await DisplayAlert("HTML file is saved", "Success", "OK");
    }
}


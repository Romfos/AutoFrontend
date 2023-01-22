using AutoFrontend.Models;
using AutoFrontend.WindowsForms.Controls;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms;

public partial class AutoFrontendFrom : Form
{
    public AutoFrontendFrom()
    {
        InitializeComponent();
    }

    public void SetFrontend(Frontend frontend)
    {
        foreach (var service in frontend.Services)
        {
            var tabPage = new TabPage(service.Name);
            var flowLayoutPanel = new FlowLayoutPanel();

            foreach (var function in service.Functions)
            {
                var functionFrontend = new FunctionFrontend();
                functionFrontend.SetFunction(function, frontend.Components);
                flowLayoutPanel.Controls.Add(functionFrontend);
            }

            tabPage.Controls.Add(flowLayoutPanel);
            tabs.TabPages.Add(tabPage);
        }
    }
}

using AutoFrontend.Models;
using AutoFrontend.WindowsForms.Controls;
using AutoFrontend.WindowsForms.Services;
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
        var componentFactroy = new ComponentFactroy(frontend.Components);

        foreach (var service in frontend.Services)
        {
            var tabPage = new TabPage(service.Name);
            tabs.TabPages.Add(tabPage);

            var flowLayoutPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            tabPage.Controls.Add(flowLayoutPanel);

            foreach (var function in service.Functions)
            {
                var functionFrontend = new FunctionControl();
                functionFrontend.SetFunction(function, componentFactroy);
                flowLayoutPanel.Controls.Add(functionFrontend);
            }
        }
    }
}

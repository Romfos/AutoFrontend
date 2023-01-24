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
            var tabPage = new TabPage(service.Name)
            {
                AutoScroll = true
            };
            tabs.TabPages.Add(tabPage);

            var panel = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            tabPage.Controls.Add(panel);

            foreach (var function in service.Functions)
            {
                var functionFrontend = new FunctionControl();
                functionFrontend.SetFunction(function, componentFactroy);
                functionFrontend.Dock = DockStyle.Top;
                panel.Controls.Add(functionFrontend);
            }
        }
    }
}

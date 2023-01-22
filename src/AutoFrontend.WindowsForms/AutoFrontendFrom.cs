using AutoFrontend.Models;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms;

public partial class AutoFrontendFrom : Form
{
    public AutoFrontendFrom()
    {
        InitializeComponent();
    }

    public void SetAutoFrontendModel(Models.Application autoFrontendModel)
    {
        foreach (var service in autoFrontendModel.Services)
        {
            var tabPage = new TabPage(service.Name);
            var flowLayoutPanel = new FlowLayoutPanel();

            foreach (var action in service.Functions)
            {
                flowLayoutPanel.Controls.Add(new Button() { Text = action.Name });
            }

            tabPage.Controls.Add(flowLayoutPanel);
            tabs.TabPages.Add(tabPage);
        }
    }
}

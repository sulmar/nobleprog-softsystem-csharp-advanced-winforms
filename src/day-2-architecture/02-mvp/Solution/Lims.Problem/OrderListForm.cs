using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lims.Problem.Model;

namespace Lims.Problem
{
    /// <summary>Lista zleceń służy tylko do otwierania ekranu edycji. Ten ekran omawiamy w module.</summary>
    public partial class OrderListForm : Form
    {
        private readonly LabOrderService _service;
        private IReadOnlyList<LabOrder> _orders;

        public OrderListForm(LabOrderService service)
        {
            InitializeComponent();

            _service = service;
            RefreshList();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (ordersListBox.SelectedIndex < 0)
            {
                return;
            }

            using (var form = new LabOrderEditForm(_service, _orders[ordersListBox.SelectedIndex].Code))
            {
                form.ShowDialog(this);
            }

            RefreshList();
        }

        private void RefreshList()
        {
            _orders = _service.All();

            ordersListBox.Items.Clear();
            foreach (var order in _orders)
            {
                ordersListBox.Items.Add(order.Code + " | " + order.PatientName + " | " + LabOrderEditForm.StatusText(order.Status));
            }

            ordersListBox.SelectedIndex = 0;
        }
    }
}

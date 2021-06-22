using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public static class FormChanging
    {
        public static void ChangeForm(Form oldForm, Form newForm)
        {
            newForm.Location = oldForm.Location;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Show();
            oldForm.Hide();
        }
    }
}

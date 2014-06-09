using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Utilities
{
        public class ListManager
        {
            public static void CargarLista(ListBox lista, object dataSource, string valueMember, string displayMember)
            {

                DataRow dr = ((DataTable)dataSource).NewRow();
                ((DataTable)dataSource).Rows.InsertAt(dr, 0);


                if (displayMember.Length > 0)
                {
                    lista.DisplayMember = displayMember;
                }
                if (valueMember.Length > 0)
                {
                    lista.ValueMember = valueMember;
                }

                lista.DataSource = dataSource;
            }
        }
    }


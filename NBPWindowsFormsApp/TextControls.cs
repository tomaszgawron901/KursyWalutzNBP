using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBPWindowsFormsApp
{
    static class TextControls
    {
        public static void Write(this TextBoxBase textbox, string text)
        {
            textbox.Text += text;
        }

        public static void Write(this TextBoxBase textbox, object obj)
        {
            textbox.Write(obj.ToString());
        }

        public static void WriteLine(this TextBoxBase textbox, string text)
        {
            textbox.Write(text + "\n");
        }

        public static void WriteLine(this TextBoxBase textbox)
        {
            textbox.Write("\n");
        }

        public static void WriteLine(this TextBoxBase textbox, object obj)
        {
            textbox.Write(obj);
            textbox.Write("\n");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    static class Program
    {
        static Food food;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            food = new Food(new System.Drawing.PointF((float)5.5, (float)4.5));
            Form1 form = new Form1();
            Application.Run(form);

            form.Paint += Form_Paint;
        }

        private static void Form_Paint(object sender, PaintEventArgs e)
        {
            food.Draw(e.Graphics);
        }
    }
}

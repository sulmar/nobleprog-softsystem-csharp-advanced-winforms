using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem
{
    public interface IFormFactory
    {
        // Metoda generyczna
        TForm Create<TForm>() where TForm : Form;
    }

    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider provider;

        public FormFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public TForm Create<TForm>() where TForm : Form
        {
            return provider.GetRequiredService<TForm>();
        }
    }
}

using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Tests.Mock
{
    class TestContactDbSet : TestDbSet<Contact>
    {
        public override Contact Find(params object[] keyValues)
        {
            return this.SingleOrDefault(contact => contact.Id == (int)keyValues.Single());
        }
    }
}

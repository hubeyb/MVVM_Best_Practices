using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMBestPractices.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Tests.UnitTests
{
    public abstract class UnitTestsBase
    {
        public MVVMBestPracticesDBcontext dBContext;

        protected virtual void MockDependencies()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            MockDependencies();
        }
    }
}

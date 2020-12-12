using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FabLabSandboxAPITest
{
    public class MakerSpaceTestData : IEnumerable<object[]>
    {
        public MakerSpaceTestData()
        {
            //Get data externally
            //Set data to local objects
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Guid.NewGuid() };
            yield return new object[] { Guid.NewGuid() };
            yield return new object[] { Guid.NewGuid() };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
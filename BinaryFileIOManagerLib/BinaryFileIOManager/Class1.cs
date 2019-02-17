using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Qazi.BinaryFileIOManager
{
    public class BinaryFileSerializationManager : IDisposable 
    {
        private Stream stream;
        private BinaryFormatter formatter;
        private object graph;
        public void Save(string fileName, object graph)
        {
            stream = File.Open(fileName, FileMode.Create);
            formatter = new BinaryFormatter();
            formatter.Serialize(stream, graph);
            formatter = null;
            stream.Close();
            stream.Dispose();
            stream = null;
        }


        public object Open(string fileName)
        {
            stream = File.Open(fileName, FileMode.Open);
            formatter = new BinaryFormatter();
            graph = formatter.Deserialize(stream);
            formatter = null;
            stream.Close();
            stream.Dispose();
            stream = null;
            return graph;
        }



        #region IDisposable Members

        public void Dispose()
        {
            formatter = null;
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
                stream = null;
            }
            graph = null;
        }

        #endregion
    }
}

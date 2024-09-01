using System.IO;

namespace Core.Service.Implements
{
    public class WaveIO
    {
        public short BitsPerSample;
        public short channels;
        public int DataLength;
        public int length;
        public int samplerate;

        private void WaveHeaderIN(string spath)
        {
            var fs = new FileStream(spath, FileMode.Open, FileAccess.Read);

            var br = new BinaryReader(fs);
            length = (int)fs.Length - 8;
            fs.Position = 22;
            channels = br.ReadInt16();
            fs.Position = 24;
            samplerate = br.ReadInt32();
            fs.Position = 34;

            BitsPerSample = br.ReadInt16();
            DataLength = (int)fs.Length - 44;
            br.Close();
            fs.Close();
        }

        private void WaveHeaderOUT(string sPath)
        {
            var fs = new FileStream(sPath, FileMode.Create, FileAccess.Write);

            var bw = new BinaryWriter(fs);
            fs.Position = 0;
            bw.Write(new char[4] { 'R', 'I', 'F', 'F' });

            bw.Write(length);

            bw.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });

            bw.Write(16);

            bw.Write((short)1);
            bw.Write(channels);

            bw.Write(samplerate);

            bw.Write(samplerate * (BitsPerSample * channels / 8));

            bw.Write((short)(BitsPerSample * channels / 8));

            bw.Write(BitsPerSample);

            bw.Write(new char[4] { 'd', 'a', 't', 'a' });
            bw.Write(DataLength);
            bw.Close();
            fs.Close();
        }

        public void Merge(string[] files, string outfile)
        {
            var wa_IN = new WaveIO();
            var wa_out = new WaveIO();

            wa_out.DataLength = 0;
            wa_out.length = 0;

            //Gather header data
            foreach (var path in files)
            {
                wa_IN.WaveHeaderIN(path);
                wa_out.DataLength += wa_IN.DataLength;
                wa_out.length += wa_IN.length;
            }

            //Recontruct new header
            wa_out.BitsPerSample = wa_IN.BitsPerSample;
            wa_out.channels = wa_IN.channels;
            wa_out.samplerate = wa_IN.samplerate;
            wa_out.WaveHeaderOUT(outfile);

            foreach (var path in files)
            {
                var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                var arrfile = new byte[fs.Length - 44];
                fs.Position = 44;
                fs.Read(arrfile, 0, arrfile.Length);
                fs.Close();

                var fo = new FileStream(outfile, FileMode.Append, FileAccess.Write);
                var bw = new BinaryWriter(fo);
                bw.Write(arrfile);
                bw.Close();
                fo.Close();
            }
        }
    }
}
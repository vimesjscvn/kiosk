using CS.Common.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;

namespace Admin.API.Domain.Services
{
    public class AudioService : IAudioService
    {
        /// <summary>
        /// The hospital settings
        /// </summary>
        private readonly HospitalSettings _hospitalSettings;
        public AudioService(HospitalSettings hospitalSettings)
        {
            _hospitalSettings = hospitalSettings;
        }

        public string CreateAudio(string path, string table, int numberFrom, int numberTo, RoomType type, PriorityType typePatient)
        {
            var filePathExist = string.Format(@"{0}\{1}\{2}_{3}_{4}_number_result.wav", path, table, typePatient, numberFrom, numberTo);
            var fileName = string.Format(@"Audio\{0}\{1}_{2}_{3}_number_result.wav", table, typePatient, numberFrom, numberTo);
            if (File.Exists(filePathExist))
            {
                return fileName;
            }
            else
            {
                if (!Directory.Exists(string.Format(@"{0}\{1}\", path, table)))
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}\", path, table));
                }
            }

            try
            {
                var arrFrom = GetIntArray(numberFrom);
                var arrTo = GetIntArray(numberTo);

                if (arrFrom.Count == 0 && arrTo.Count == 0)
                {
                    return string.Empty;
                }

                List<string> listResult = new List<string>();
                if (typePatient == PriorityType.Priority)
                {
                    listResult.Add(string.Format(@"{0}\Priority.wav", path));
                }
                else
                {
                    listResult.Add(string.Format(@"{0}\InvetePatient.wav", path));
                }

                for (int i = 0; i < 2; i++)
                {
                    var arr = new List<int>();
                    if (i == 0)
                    {
                        arr = arrFrom;
                    }
                    else
                    {
                        listResult.Add(string.Format(@"{0}\ToNumber.wav", path));
                        arr = arrTo;
                    }

                    CreateListPath(arr, path, ref listResult);
                }

                switch (type)
                {
                    case RoomType.NS:
                        {
                            listResult.Add(string.Format(@"{0}\GotoRoomNoiSoi.wav", path));
                            AppendRoom(table, path, ref listResult);
                            break;
                        }

                    case RoomType.SA:
                        {
                            listResult.Add(string.Format(@"{0}\GotoRoomSieuAm.wav", path));
                            AppendRoom(table, path, ref listResult);
                            break;
                        }
                }

                Concatenate(filePathExist, listResult);
                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Create Audio Single
        /// </summary>
        /// <param name="path"></param>
        /// <param name="table"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public string CreateAudioSingle(string path, string table, PriorityType type, int number)
        {
            var filePathExist = string.Format(@"{0}\{1}\{2}_{3}_number_result.wav", path, table, type, number);
            var pathName = string.Format(@"Audio\{0}\{1}_{2}_number_result.wav", table, type, number);

            if (File.Exists(filePathExist))
            {
                return pathName;
            }
            else
            {
                if (!Directory.Exists(string.Format(@"{0}\{1}\", path, table)))
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}\", path, table));
                }
            }

            try
            {
                var arr = GetIntArray(number);

                if (arr.Count == 0)
                {
                    return string.Empty;
                }

                List<string> listResult = new List<string>();

                if (type == PriorityType.Priority)
                {
                    listResult.Add(string.Format(@"{0}\Priority.wav", path));
                }
                else
                {
                    listResult.Add(string.Format(@"{0}\InvetePatient.wav", path));
                }

                CreateListPath(arr, path, ref listResult);

                listResult.Add(string.Format(@"{0}\GoToRoom.wav", path));

                Concatenate(filePathExist, listResult);
                return pathName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Create Audio Single
        /// </summary>
        /// <param name="path"></param>
        /// <param name="table"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<string> CreateAudioSingleEndoscopic(string path,
            string table,
            PriorityType type,
            int number,
            string virtualRoomCode,
            int displayyOrder,
            string urlAudioDepartment)
        {
            var filePathExist = string.Format(@"{0}\{1}\{2}_{3}_{4}number_result.wav", path, table, type, virtualRoomCode, number);
            var pathName = string.Format(@"Audio\{0}\{1}_{2}_{3}number_result.wav", table, type, virtualRoomCode, number);

            if (File.Exists(filePathExist))
            {
                return pathName;
            }
            else
            {
                if (!Directory.Exists(string.Format(@"{0}\{1}\", path, table)))
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}\", path, table));
                }
            }

            //try
            //{
            //    var arr = GetIntArray(number);

            //    if (arr.Count == 0)
            //    {
            //        return string.Empty;
            //    }

            //    List<string> listResult = new List<string>();

            //    if (type == PriorityType.Priority)
            //    {
            //        listResult.Add(string.Format(@"{0}\Priority.wav", path));
            //    }
            //    else
            //    {
            //        listResult.Add(string.Format(@"{0}\InvetePatient.wav", path));
            //    }

            //    CreateListPath(arr, path, ref listResult);

            //    listResult.Add(string.Format(@"{0}\GoRoom.wav", path));
            //    var arrDisplayOrder = GetIntArray(displayyOrder);
            //    CreateListPath(arrDisplayOrder, path, ref listResult);

            //    var wc = new System.Net.WebClient();
            //    var fileAudio = "wwwroot" + urlAudioDepartment;

            //    if (File.Exists(fileAudio))
            //    {
            //        listResult.Add(fileAudio);
            //    }
            //    //var isSuccess = false;
            //    //try
            //    //{
            //    //    wc.DownloadFile(_hospitalSettings.Hospital.BaseUrlDepartment + urlAudioDepartment, fileAudio);
            //    //    isSuccess = true;
            //    //}
            //    //catch
            //    //{
            //    //    isSuccess = false;
            //    //}
            //    //if (isSuccess)
            //    //{
            //    //    listResult.Add(fileAudio);
            //    //}

            //    Concatenate(filePathExist, listResult);

            //    //if (File.Exists(fileAudio))
            //    //{
            //    //    File.Delete(fileAudio);
            //    //}

            //    return pathName;
            //}
            try
            {
                List<string> listResult = new List<string>();

                //var fileAudioDepartment = "wwwroot" + urlAudioDepartment;
                //if (File.Exists(fileAudioDepartment))
                //{
                //    listResult.Add(fileAudioDepartment);
                //}

                var urlDisplayOrder = $"{path}\\room_{displayyOrder}.wav";
                if (File.Exists(urlDisplayOrder))
                {
                    listResult.Add(urlDisplayOrder);
                }
                else
                {
                    listResult.Add(string.Format(@"{0}\room.wav", path));
                    var arrDisplayOrder = GetIntArray(displayyOrder);
                    CreateListPath(arrDisplayOrder, path, ref listResult);
                }

                if (type == PriorityType.Priority)
                {
                    listResult.Add(string.Format(@"{0}\Priority.wav", path));
                }
                else
                {
                    listResult.Add(string.Format(@"{0}\InvetePatient.wav", path));
                }

                var urlNumber = $"{path}\\number_{number}.wav";
                if (File.Exists(urlNumber))
                {
                    listResult.Add(urlNumber);
                }

                Concatenate(filePathExist, listResult);
                return pathName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string CreateAudioReceptionTable(
            string webRoot,
            string requestTable,
            int requestFrom,
            int requestTo,
            int type,
            string departmentCode,
            bool isRecall = false)
        {
            try
            {
                if (requestFrom <= 0 || requestTo <= 0)
                {
                    return "";
                }

                var filePathExist = $"{webRoot}\\Audio\\AudioTNB\\table{requestTable}_code{departmentCode}_type{type}_from{requestFrom}_to{requestTo}.mp3";
                var pathName = $"Audio\\AudioTNB\\table{requestTable}_code{departmentCode}_type{type}_from{requestFrom}_to{requestTo}.mp3";

                if (isRecall)
                {
                    filePathExist = $"{webRoot}\\Audio\\AudioTNB\\table{requestTable}_code{departmentCode}_type{type}_from{requestFrom}_to{requestTo}_recall.mp3";
                    pathName = $"Audio\\AudioTNB\\table{requestTable}_code{departmentCode}_type{type}_from{requestFrom}_to{requestTo}_recall.mp3";
                }

                if (File.Exists(filePathExist))
                {
                    return pathName;
                }

                var departmentText = string.Empty;
                if (departmentCode == "TATTOAN")
                {
                    departmentText = "thanh toán";
                }
                else if (departmentCode == "TNB")
                {
                    departmentText = "tiếp đón";
                }

                string template = $"Mời bệnh nhân {departmentText} từ số {requestFrom} đến số {requestTo} vào bàn số {requestTable}";
                if (requestFrom == requestTo)
                {
                    template = $"Mời bệnh nhân {departmentText} có số {requestFrom} vào bàn số {requestTable}";
                }

                if (type != 0)
                {
                    template = $"Mời bệnh nhân ưu tiên từ số {requestFrom} đến số {requestTo} vào bàn số {requestTable}";
                    if (requestFrom == requestTo)
                    {
                        template = $"Mời bệnh nhân {departmentText} ưu tiên có số {requestFrom} vào bàn số {requestTable}";
                    }
                }

                var url = "http://54.254.17.74:3000/?text=" + template;
                using (var client = new WebClient())
                {
                    client.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InZpbWVzIiwicm9sZSI6InN5c3RlbSIsImlhdCI6MTY5OTI1Njg4MH0.U_Cn6XIhgPFSieVloSZGMxofG-Nq8aja1MfcdhM5IFc");
                    client.DownloadFile(url, filePathExist);
                }

                return pathName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CreateAudioDepartment(
            string webRoot,
            string group,
            int requestFrom,
            int requestTo,
            int type,
            string departmentCode,
            string departmentName,
            string patientName)
        {
            try
            {
                if (requestFrom <= 0 || requestTo <= 0)
                {
                    return "";
                }

                var idx = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                var filePathExist = $"{webRoot}\\Audio\\AudioDept\\group{group}_code{departmentCode}_type{type}_from{requestFrom}_to{requestTo}_idx{idx}.mp3";
                var pathName = $"Audio\\AudioDept\\group{group}_code{departmentCode}_type{type}_from{requestFrom}_to{requestTo}_idx{idx}.mp3";
                if (File.Exists(filePathExist))
                {
                    return pathName;
                }

                string template = $"Mời bệnh nhân {patientName} từ số {requestFrom} đến số {requestTo} vào {departmentName}";
                if (requestFrom == requestTo)
                {
                    template = $"Mời bệnh nhân {patientName} có số {requestFrom} vào {departmentName}";
                }

                if (type != 0)
                {
                    template = $"Mời bệnh nhân ưu tiên từ số {requestFrom} đến số {requestTo} vào {departmentName}";
                    if (requestFrom == requestTo)
                    {
                        template = $"Mời bệnh nhân {patientName} ưu tiên có số {requestFrom} vào {departmentName}";
                    }
                }

                var url = "http://54.254.17.74:3000/?text=" + template;
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, filePathExist);
                }

                return pathName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #region Private Method

        /// <summary>
        /// Create List Path
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private void AppendRoom(string table, string path, ref List<string> listResult)
        {
            switch (table)
            {
                case RoomTypeSA.SAKHUB9:
                    {
                        listResult.Add(string.Format(@"{0}\number_9.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB8:
                    {
                        listResult.Add(string.Format(@"{0}\number_8.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB7:
                    {
                        listResult.Add(string.Format(@"{0}\number_7.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB6:
                    {
                        listResult.Add(string.Format(@"{0}\number_6.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB5:
                    {
                        listResult.Add(string.Format(@"{0}\number_5.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB4:
                    {
                        listResult.Add(string.Format(@"{0}\number_4.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB3:
                    {
                        listResult.Add(string.Format(@"{0}\number_3.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB2:
                    {
                        listResult.Add(string.Format(@"{0}\number_2.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB1:
                    {
                        listResult.Add(string.Format(@"{0}\number_1.wav", path));
                        break;
                    }

                case RoomTypeSA.SAKHUB10:
                    {
                        listResult.Add(string.Format(@"{0}\number_1.wav", path));
                        listResult.Add(string.Format(@"{0}\number_0.wav", path));
                        break;
                    }

                case RoomTypeSA.NOISOIK3:
                case RoomTypeSA.NOISOIK4:
                case RoomTypeSA.NOISOIK31:
                case RoomTypeSA.NOISOIK2:
                case RoomTypeSA.NOISOIK21:
                case RoomTypeSA.NOISOIK41:
                case RoomTypeSA.NOISOIK1:
                    {
                        listResult.Add(string.Format(@"{0}\number_1.wav", path));
                        break;
                    }

                case RoomTypeSA.NOISOIK12:
                case RoomTypeSA.NOISOIK32:
                case RoomTypeSA.NOISOIK22:
                case RoomTypeSA.NOISOIK42:
                    {
                        listResult.Add(string.Format(@"{0}\number_2.wav", path));
                        break;
                    }

                case RoomTypeSA.NOISOIK13:
                case RoomTypeSA.NOISOIK23:
                    {
                        listResult.Add(string.Format(@"{0}\number_3.wav", path));
                        break;
                    }

                case RoomTypeSA.NOISOIK24:
                    {
                        listResult.Add(string.Format(@"{0}\number_4.wav", path));
                        break;
                    }

                case RoomTypeSA.NOISOIK25:
                    {
                        listResult.Add(string.Format(@"{0}\number_5.wav", path));
                        break;
                    }
            }
        }

        /// <summary>
        /// Create List Path
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private void CreateListPath(List<int> arr, string path, ref List<string> listResult)
        {
            foreach (var item in arr)
            {
                switch (item)
                {
                    case 9:
                        {
                            listResult.Add(string.Format(@"{0}\number_9.wav", path));
                            break;
                        }

                    case 8:
                        {
                            listResult.Add(string.Format(@"{0}\number_8.wav", path));
                            break;
                        }

                    case 7:
                        {
                            listResult.Add(string.Format(@"{0}\number_7.wav", path));
                            break;
                        }

                    case 6:
                        {
                            listResult.Add(string.Format(@"{0}\number_6.wav", path));
                            break;
                        }

                    case 5:
                        {
                            listResult.Add(string.Format(@"{0}\number_5.wav", path));
                            break;
                        }

                    case 4:
                        {
                            listResult.Add(string.Format(@"{0}\number_4.wav", path));
                            break;
                        }

                    case 3:
                        {
                            listResult.Add(string.Format(@"{0}\number_3.wav", path));
                            break;
                        }

                    case 2:
                        {
                            listResult.Add(string.Format(@"{0}\number_2.wav", path));
                            break;
                        }

                    case 1:
                        {
                            listResult.Add(string.Format(@"{0}\number_1.wav", path));
                            break;
                        }

                    case 0:
                        {
                            listResult.Add(string.Format(@"{0}\number_0.wav", path));
                            break;
                        }
                }
            }
        }

        private List<int> GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            if (num == 0)
            {
                listOfInts.Add(0);
            }
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();
            return listOfInts;
        }

        private void Concatenate(string outputFile, List<string> sourceFiles)
        {
            WaveIO wave = new WaveIO();
            wave.Merge(sourceFiles.ToArray(), outputFile);
        }
        #endregion
    }
}

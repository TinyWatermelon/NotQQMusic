using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotQQMuisc
{
    public static class SearchPageitems
    {
        public static ObservableCollection<MusicItem> GetSearchPageitems(string n)
        {
            ObservableCollection<MusicItem> collection = new ObservableCollection<MusicItem>();
            for (int k = 0; k < 9; k++)
            {
                string json = GetJson.Getjson("https://route.showapi.com/213-1?keyword="+n+"&page=1&showapi_appid=19055&showapi_sign=7228bab0675f44c3a8bcca63296e4ca3");
                JsonReader reader = new JsonTextReader(new StringReader(json));
                bool isitValue = false;
                string[] temp = new string[6];
                int i = 0;
                while (reader.Read())
                {
                    if (reader.Value == null)
                        continue;
                    else
                    {
                        if (isitValue)
                        {
                            temp[i] = reader.Value.ToString();
                            i++;
                            isitValue = false;
                            if (i == 6)
                            {
                                collection.Add(new MusicItem
                                {
                                    albumname = temp[0],
                                    albumpic_big = temp[1],
                                    albumpic_small = temp[2],
                                    downUrl = temp[3],
                                    singername = temp[4],
                                    songname = n
                                });
                                i = 0;
                            }
                        }
                        else if (reader.Value.ToString().Equals("albumname"))
                        {
                            isitValue = true;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("albumpic_big"))
                        {
                            isitValue = true;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("albumpic_small"))
                        {
                            isitValue = true;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("downUrl"))
                        {
                            isitValue = true;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("singername"))
                        {
                            isitValue = true;
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return collection;

        }
    }
}

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
                string[] temp = new string[5];
                int i = 0,j=0;
                while (reader.Read())
                {
                    if (reader.Value == null)
                        continue;
                    else
                    {
                        if (j!=0)
                        {
                            temp[j-1] = reader.Value.ToString();
                            i++;
                            j = 0;
                            if (i == 5)
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
                            j = 1;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("albumpic_big"))
                        {
                            j = 2;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("albumpic_small"))
                        {
                            j = 3;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("downUrl"))
                        {
                            j = 4;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("singername"))
                        {
                            j = 5;
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

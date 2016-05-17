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
    public static class MainPageitems
    {
        public static ObservableCollection<MusicItem> GetMainPageitems()
        {
            ObservableCollection<MusicItem> collection = new ObservableCollection<MusicItem>();
            int[] num = { 5, 6, 3, 16, 17, 18, 19, 23, 26 };
            for (int k = 0; k < 9; k++)
            {
                string json = GetJson.Getjson("https://route.showapi.com/213-4?showapi_appid=19055&topid=" + num[k]+"&showapi_sign=7228bab0675f44c3a8bcca63296e4ca3");
                JsonReader reader = new JsonTextReader(new StringReader(json));
                string[] temp = new string[6];
                int i = 0,j=0,l=0;
                while (reader.Read())
                {
                    if (reader.Value == null)
                    {
                        continue;
                    }
                    else
                    { 
                        if (l!=0)
                        {
                            temp[l-1] = reader.Value.ToString();
                            i++;
                            l = 0;
                            if (i == 6)
                            {
                                collection.Add(new MusicItem
                                {
                                    albumpic_big = temp[0],
                                    albumpic_small = temp[1],
                                    downUrl = temp[2],
                                    seconds = temp[3],
                                    singername = temp[4],
                                    songname = temp[5]
                                });
                                i = 0;
                                j++;
                                if (j == 3)
                                {
                                    break;
                                }
                            }
                        }
                        else if (reader.Value.ToString().Equals("albumpic_big"))
                        {
                            l = 1;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("albumpic_small"))
                        {
                            l = 2;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("downUrl"))
                        {
                            l = 3;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("seconds"))
                        {
                            l = 4;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("singername"))
                        {
                            l = 5;
                            continue;
                        }
                        else if (reader.Value.ToString().Equals("songname"))
                        {
                            l = 6;
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

using E_Diary_for_Windows.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace E_Diary_for_Windows.Utils {
    public class ImageUtils {
        public static Image LoadImage(string url) {
            if (url == null) {
                return Resources.noavatar;
            }
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK
                && response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase)) {
                using (Stream stream = response.GetResponseStream()) {
                    return Image.FromStream(stream);
                }
            }
            return Resources.noavatar;
        }
    }
}

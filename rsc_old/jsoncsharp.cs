HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://fr.wikipedia.org/w/api.php?format=json&action=query&prop=revisions&rvprop=content&rvsection=0&rvparse&titles=" + monuments);
using (HttpWebResponse response = (HttpWebResponse)(await myRequest.GetResponseAsync()))
{
      string ResponseText;
      string[] ResponseArray;
      string test;
      string tests;
      using (StreamReader reader = new StreamReader(response.GetResponseStream()))
      {
            ResponseText = reader.ReadToEnd();
            ResponseArray = ResponseText.Split(new string[] { "\"pageid\"" }, StringSplitOptions.None);
            test = "{ \"pageid\"" + ResponseArray[1];
            tests = test.Replace("}]}}}}", "}]}");

            Debug.WriteLine(string.Join(", ", ResponseText));
            Debug.WriteLine(string.Join(", ", tests));*/
            InfoMonuments objJson = new InfoMonuments();

            objJson = JsonConvert.DeserializeObject<InfoMonuments>(tests);
            foreach (string element in (dynamic)(objJson.revisions[0])) {
                  Debug.WriteLine(element);
                  var localFolder = ApplicationData.Current.LocalFolder;
                  var pageHtml = await localFolder.CreateFileAsync("page.html",
                                                          CreationCollisionOption.OpenIfExists);

                  await FileIO.WriteTextAsync(pageHtml, element);

                  Uri testHtml = new Uri("http://fr.wikipedia.org/wiki/Taj_Mahal");
                  WebContainer.Navigate(testHtml);
            }
      }
}
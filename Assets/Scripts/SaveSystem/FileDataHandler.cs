using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileDataHandler
{
   private string dataDirPath = "";
   private string dataFileName = "";


   public FileDataHandler(string dataDirPath, string dataFileName)
   {
      this.dataDirPath = dataDirPath;
      this.dataFileName = dataFileName;
   }

   public GameData Load()
   {
      string fullPath = Path.Combine(dataDirPath, dataFileName);
      GameData loadedData = null;

      if (File.Exists(fullPath))
      {
         try
         {
            string dataToLoad = "";
            using (FileStream stream = new FileStream(fullPath, FileMode.Open)) 
            {
               using (StreamReader streamReader = new StreamReader(stream))
               {
                  dataToLoad = streamReader.ReadToEnd();
               }
            }
            
            loadedData = Newtonsoft.Json.JsonConvert.DeserializeObject<GameData>(dataToLoad);


         }
         catch (Exception e)
         {
            Debug.LogError("Error occured when trying to load data from the file " + fullPath + "\n" + e);
            throw;
         }
      }

      return loadedData;
   }

   public void Save(GameData data)
   {
      string fullPath = Path.Combine(dataDirPath, dataFileName);
      try
      {
         Directory.CreateDirectory(Path.GetDirectoryName(fullPath) ?? string.Empty);
         string dataToStore = Newtonsoft.Json.JsonConvert.SerializeObject(data);
         
         using (FileStream stream = new FileStream(fullPath, FileMode.Create)) 
         {
            using (StreamWriter streamWriter = new StreamWriter(stream))
            {
               streamWriter.Write(dataToStore);
            }
         }
      }
      catch (Exception e)
      {
         Debug.LogError("Error occured when trying to save data to file " + fullPath + "\n" + e);
         throw;
      }
   }
}

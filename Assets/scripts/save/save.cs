using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class save{
	private static bool inUse = false;

    public static void SavePlayer(UserData player){
        if(inUse)
            return;

        inUse = true;
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.save";
        FileStream stream = new FileStream(path,FileMode.Create);

        FormatedData data = new FormatedData(player);
        formatter.Serialize(stream,data);
        stream.Close();
        inUse = false;
    }

	public static FormatedData LoadPlayer(){
    	if(inUse)
    	return null;

    	inUse = true;
    	string path = Application.persistentDataPath + "/data.save";
    	if(File.Exists(path)){
    		BinaryFormatter formatter = new BinaryFormatter();
    		FileStream stream = new FileStream(path,FileMode.Open);

    		FormatedData data = formatter.Deserialize(stream) as FormatedData;
    		stream.Close();
    		inUse = false;
    		return data;
    	}else{
    		Debug.LogError("Save file not found !");
    		inUse = false;
    		return null;
    	}
    	
    }
}

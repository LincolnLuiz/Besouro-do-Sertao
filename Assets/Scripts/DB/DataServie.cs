using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using SQLite4Unity3d;
using System.Collections.Generic;

public class DataService  {
	
	public ISQLiteConnection _connection;
	
	public DataService(string DatabaseName) {
		
		var factory = new Factory();
		
		#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
		if (!File.Exists(filepath))
		{
			Debug.Log("Database not in Persistent path");
			// if it doesn't ->
			// open StreamingAssets directory and load the db ->
			
			#if UNITY_ANDROID 
			var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
			while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
			// then save to Application.persistentDataPath
			File.WriteAllBytes(filepath, loadDb.bytes);
			#elif UNITY_IOS
			var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			#elif UNITY_WP8
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			
			#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			#endif
			
			Debug.Log("Database written");
		}
		
		var dbPath = filepath;
		#endif
		_connection = factory.Create(dbPath);
		Debug.Log("Final PATH: " + dbPath);     
		
	}

	public int getEstrelas(int sertao) {
		var Levels = _connection.Table<Level> ();
		
		int estrelas = 0;
		
		foreach (var level in Levels) {
			if (level.IdSertao == sertao) {
				estrelas += level.Estrela;
			}
		}
		
		return estrelas;
	}

	public Level getLevel(int Numero, int IdSertao) {
		return _connection.Table<Level>().Where(x => x.Numero == Numero).Where(x => x.IdSertao == IdSertao).FirstOrDefault();
	}

	public void CreateDB() {
		//PlayerPrefs.DeleteAll ();
		// criar tabelas primeira instalacao
		if (PlayerPrefs.GetInt ("versionDB") == 0) {
			Debug.Log("Criou tabela");     
			// criar tabelas
			_connection.DropTable<Level> ();
			_connection.CreateTable<Level> ();
			
			// criar registros de leveis
			_connection.InsertAll(new[] {
				new Level {
					IdSertao = 1,
					Numero = 1,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 5,
					Estrela2 = 10,
					Estrela3 = 15,
					RateSpaw = 2.8f,
					Velocidade = -3f,
					Bloqueio = 0
				},
				new Level {
					IdSertao = 1,
					Numero = 2,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 5,
					Estrela2 = 10,
					Estrela3 = 15,
					RateSpaw = 2.8f,
					Velocidade = -3.5f,
					Bloqueio = 5
				},
				new Level {
					IdSertao = 1,
					Numero = 3,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 5,
					Estrela2 = 10,
					Estrela3 = 15,
					RateSpaw = 2,
					Velocidade = -3.5f,
					Bloqueio = 5
				},
				new Level {
					IdSertao = 1,
					Numero = 4,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 8,
					Estrela2 = 12,
					Estrela3 = 16,
					RateSpaw = 3,
					Velocidade = -3.8f,
					Bloqueio = 5
				},
				new Level {
					IdSertao = 1,
					Numero = 5,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 5,
					Estrela2 = 10,
					Estrela3 = 20,
					RateSpaw = 3,
					Velocidade = -4,
					Bloqueio = 8
				},
				new Level {
					IdSertao = 1,
					Numero = 6,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 9,
					Estrela2 = 14,
					Estrela3 = 22,
					RateSpaw = 2.5f,
					Velocidade = -3,
					Bloqueio = 5
				},
				new Level {
					IdSertao = 1,
					Numero = 7,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 10,
					Estrela2 = 20,
					Estrela3 = 30,
					RateSpaw = 2,
					Velocidade = -3.5f,
					Bloqueio = 9
				},
				new Level {
					IdSertao = 1,
					Numero = 8,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 15,
					Estrela2 = 35,
					Estrela3 = 50,
					RateSpaw = 1.5f,
					Velocidade = -4,
					Bloqueio = 10
				},
				new Level {
					IdSertao = 1,
					Numero = 9,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 15,
					Estrela2 = 30,
					Estrela3 = 45,
					RateSpaw = 1.4f,
					Velocidade = -3.8f,
					Bloqueio = 15
				},
				new Level {
					IdSertao = 1,
					Numero = 10,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 20,
					Estrela2 = 45,
					Estrela3 = 60,
					RateSpaw = 1.8f,
					Velocidade = -5,
					Bloqueio = 15
				},
				
				new Level {
					IdSertao = 2,
					Numero = 1,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 10,
					Estrela2 = 15,
					Estrela3 = 25,
					RateSpaw = 2.8f,
					Velocidade = -3f,
					Bloqueio = 0
				},
				new Level {
					IdSertao = 2,
					Numero = 2,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 10,
					Estrela2 = 15,
					Estrela3 = 25,
					RateSpaw = 2.8f,
					Velocidade = -3.5f,
					Bloqueio = 10
				},
				new Level {
					IdSertao = 2,
					Numero = 3,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 10,
					Estrela2 = 20,
					Estrela3 = 30,
					RateSpaw = 2,
					Velocidade = -3.5f,
					Bloqueio = 10
				},
				new Level {
					IdSertao = 2,
					Numero = 4,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 16,
					Estrela2 = 24,
					Estrela3 = 32,
					RateSpaw = 3,
					Velocidade = -3.8f,
					Bloqueio = 10
				},
				new Level {
					IdSertao = 2,
					Numero = 5,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 10,
					Estrela2 = 20,
					Estrela3 = 40,
					RateSpaw = 3,
					Velocidade = -4,
					Bloqueio = 16
				},
				new Level {
					IdSertao = 2,
					Numero = 6,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 18,
					Estrela2 = 28,
					Estrela3 = 44,
					RateSpaw = 2.5f,
					Velocidade = -3,
					Bloqueio = 10
				},
				new Level {
					IdSertao = 2,
					Numero = 7,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 20,
					Estrela2 = 40,
					Estrela3 = 60,
					RateSpaw = 2,
					Velocidade = -3.5f,
					Bloqueio = 18
				},
				new Level {
					IdSertao = 2,
					Numero = 8,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 30,
					Estrela2 = 70,
					Estrela3 = 100,
					RateSpaw = 1.5f,
					Velocidade = -4,
					Bloqueio = 20
				},
				new Level {
					IdSertao = 2,
					Numero = 9,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 30,
					Estrela2 = 60,
					Estrela3 = 90,
					RateSpaw = 1.4f,
					Velocidade = -3.8f,
					Bloqueio = 30
				},
				new Level {
					IdSertao = 2,
					Numero = 10,
					Recorde = 0,
					Estrela = 0,
					Estrela1 = 40,
					Estrela2 = 90,
					Estrela3 = 120,
					RateSpaw = 1.8f,
					Velocidade = -5,
					Bloqueio = 30
				},
			});
			
			// define versao
			PlayerPrefs.SetInt("versionDB", 1);
		}
		
		// verifica se a versao he antiga
		if (PlayerPrefs.GetInt ("versionDB") < 2) {
			// atualizar tabelas segundo instalacoes
			//DS._connection.CreateTable<Level>();
			
			//PlayerPrefs.SetInt("versionDB", 4);
		}
	}
}

using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Level {

	[AutoIncrement][PrimaryKey]
	public int Id { get; set; }
	public int IdSertao { get; set; }
	public int Numero { get; set; }
	public int Recorde { get; set; }
	public int Estrela { get; set; }
	public int Tempo { get; set; }
	public int Bloqueio { get; set; }
	public float RateSpaw { get; set; }
	// maxima = 5.63
	// mamino = 6.46
	public float Espaco { get; set; }
	public float Velocidade { get; set; }
	public int Estrela1 { get; set; }
	public int Estrela2 { get; set; }
	public int Estrela3 { get; set; }
}

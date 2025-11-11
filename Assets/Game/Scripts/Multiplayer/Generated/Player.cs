// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.46
// 

using Colyseus.Schema;

public partial class Player : Schema {
	[Type(0, "uint16")]
	public ushort weapon = default(ushort);

	[Type(1, "uint16")]
	public ushort loss = default(ushort);

	[Type(2, "uint16")]
	public ushort health = default(ushort);

	[Type(3, "uint16")]
	public ushort currentHealth = default(ushort);

	[Type(4, "number")]
	public float speed = default(float);

	[Type(5, "number")]
	public float pX = default(float);

	[Type(6, "number")]
	public float pY = default(float);

	[Type(7, "number")]
	public float pZ = default(float);

	[Type(8, "number")]
	public float vX = default(float);

	[Type(9, "number")]
	public float vY = default(float);

	[Type(10, "number")]
	public float vZ = default(float);

	[Type(11, "number")]
	public float rX = default(float);

	[Type(12, "number")]
	public float rY = default(float);

	[Type(13, "boolean")]
	public bool cr = default(bool);
}


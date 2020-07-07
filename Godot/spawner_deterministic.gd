extends MeshInstance

var x_pos= 0
var z_pos= 0
var y_pos= 0
var spawning_time_after


# Called when the node enters the scene tree for the first time.
func _ready():
	var agent_scene = load("res://agent.tscn")
	#var agent = []
	
	for i in range(0, game_manager.agent_count):
		
		#agent.append(agent_scene.instance()) 
		#add_child(agent[i])
		var agent = agent_scene.instance()
		agent.translation=(Vector3(x_pos,y_pos,z_pos))
		z_pos=z_pos+10
		add_child(agent)
	spawning_time_after=OS.get_ticks_msec()
	game_manager.spawning_time_after=spawning_time_after

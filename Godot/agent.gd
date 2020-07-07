extends KinematicBody

var path = []
var path_ind = 0
var goal: Vector3
var move_speed
var agent_time_start=0
var agent_time_end=0
var agent_time_in=0
var agent_time_out=0
var in_gate_latch=false
var out_gate_latch=false

onready var nav = get_parent().get_parent()
func _ready():
	add_to_group("units")
	move_speed=game_manager.agent_speed
	goal= Vector3(9999,9999,9999)

	

func _physics_process(delta: float):
	if path_ind < path.size():
		var move_vec = (path[path_ind] - global_transform.origin)
		if move_vec.length() < 0.1:
			path_ind += 1
		else:
			move_and_slide(move_vec.normalized() * move_speed, Vector3(0, 1, 0))
	if (global_transform.origin.distance_to(goal) <0.2):
		if(agent_time_end==0):
			agent_time_end=OS.get_ticks_msec()
			var time_string:String
			time_string=str(agent_time_start)+";"+str(agent_time_end)+";"+str(agent_time_in)+";"+str(agent_time_out)
			game_manager.agent_times.append(time_string)

func move_to():
	if(agent_time_start==0):
			agent_time_start=OS.get_ticks_msec()
			if get_tree().current_scene.name=="deterministic":
				var distance=(floor(game_manager.agent_count/1)*10)+200
				goal=global_transform.origin+Vector3(0,0,-distance)
			else:
				var distance=(floor(1000/20)*10)+300
				goal=global_transform.origin+Vector3(0,0,-distance)
	goal[1]=global_transform.origin[1]
	path = nav.get_simple_path(global_transform.origin, goal)
	path_ind = 0
	

func _on_Area_area_entered(area: Area):
	if (area.name=="Area_gate_in" && in_gate_latch==false):
		agent_time_in=OS.get_ticks_msec()
		in_gate_latch=true
	if (area.name=="Area_gate_out" && out_gate_latch==false):
		agent_time_out=OS.get_ticks_msec()
		out_gate_latch=true
	

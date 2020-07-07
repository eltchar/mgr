extends Node

var agent_count = 1
var agent_speed = 10
var level_load_time_before
var spawning_time_after
var agent_times = []
var path_to_file :String
var path_to_fps_file :String

# Called when the node enters the scene tree for the first time.
func _ready():
	pass
	


func change_level(scene_to_be_loaded: String):
	level_load_time_before=OS.get_ticks_msec()
	get_tree().change_scene(scene_to_be_loaded)
	agent_times.clear()
	var time_prefix= OS.get_time()
	var string_time:String=str(time_prefix["hour"])+"_"+str(time_prefix["minute"])+"_"+str(time_prefix["second"])
	path_to_file="d://Times_log_godot"+string_time+".txt"
	path_to_fps_file="d://FPS_log_godot"+string_time+".txt"
	
func save_data():
	var file = File.new()
	file.open(path_to_file,file.WRITE)
	file.close()
	file.open(path_to_file,file.READ_WRITE)
	file.seek_end()
	var text=str(spawning_time_after-level_load_time_before)+"\r\n"
	file.store_string(text)
	for i in agent_times:
		text=i+"\r\n"
		file.store_string(text)
	file.close()

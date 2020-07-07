extends Spatial

var timer = null
var timer2 = null

func _ready():
	timer = Timer.new()
	timer.set_wait_time(0.3);
	timer.connect("timeout",self,"on_timeout_compelete")
	add_child(timer)
	var file = File.new()
	file.open(game_manager.path_to_fps_file,file.WRITE)
	file.close()
	timer2 = Timer.new()
	timer2.set_wait_time(1);
	timer2.connect("timeout",self,"_on_Button_start_test_pressed")
	add_child(timer2)
	timer2.start()
	


func on_timeout_compelete():
	get_tree().call_group("units", "move_to")


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float):
	var fps
	if delta>0:
		fps = 1.0 / delta
	else:
		fps = "-"
	var file = File.new()
	file.open(game_manager.path_to_fps_file,file.READ_WRITE)
	file.seek_end()
	var text=str(fps)+","+str(Performance.get_monitor(Performance.TIME_FPS))+"\r\n"
	file.store_string(text)
	file.close()
	if game_manager.agent_times.size()==game_manager.agent_count:
		game_manager.save_data()
		game_manager.change_level("res://main_menu_ui.tscn")
		

func _on_Button_start_test_pressed():
	timer.start()
	timer2.stop()


func _on_Button_back_pressed():
	game_manager.change_level("res://main_menu_ui.tscn")
	


func _on_Button_save_data_pressed():
	game_manager.save_data()

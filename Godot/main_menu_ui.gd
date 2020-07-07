extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	$GridContainer/VBoxContainer2/SpinBox_number_of_agents.value=game_manager.agent_count
	$GridContainer/VBoxContainer2/SpinBox_agent_speed.value=game_manager.agent_speed


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Button_exit_pressed():
	get_tree().quit()

func _on_Button_funnel_pressed():
	game_manager.change_level("res://funnel.tscn")


func _on_Button_level5_pressed():
	game_manager.change_level("res://lab5.tscn")


func _on_Button_level4_pressed():
	game_manager.change_level("res://lab4.tscn")


func _on_Button_level3_pressed():
	game_manager.change_level("res://lab3.tscn")


func _on_Button_level2_pressed():
	game_manager.change_level("res://lab2.tscn")


func _on_Button_level1_pressed():
	game_manager.change_level("res://lab1.tscn")


func _on_SpinBox_number_of_agents_value_changed(value):
	game_manager.agent_count=value


func _on_SpinBox_agent_speed_value_changed(value):
	game_manager.agent_speed=value


func _on_Button_deterministic_pressed():
	game_manager.change_level("res://deterministic.tscn")

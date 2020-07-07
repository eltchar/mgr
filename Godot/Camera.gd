extends Camera


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var state=1
var cam_size=700
var base_pos

# Called when the node enters the scene tree for the first time.
func _ready():
	base_pos=translation


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if (Input.is_key_pressed(KEY_UP)):
		translate(Vector3(0,100*delta,0))
	if (Input.is_key_pressed(KEY_DOWN)):
		translate(Vector3(0,-100*delta,0))
	if (Input.is_key_pressed(KEY_LEFT)):
		translate(Vector3(-100*delta,0,0))
	if (Input.is_key_pressed(KEY_RIGHT)):
		translate(Vector3(100*delta,0,0))
	if (Input.is_key_pressed(KEY_Z)):
		translate(Vector3(0,0,-100*delta))
	if (Input.is_key_pressed(KEY_C)):
		translate(Vector3(0,0,100*delta))
		
	if (Input.is_key_pressed(KEY_W)):
		rotate_x(1*delta)
	if (Input.is_key_pressed(KEY_S)):
		rotate_x(-1*delta)
	if (Input.is_key_pressed(KEY_A)):
		rotate_y(1*delta)
	if (Input.is_key_pressed(KEY_D)):
		rotate_y(-1*delta)
	if (Input.is_key_pressed(KEY_Q)):
		rotate_z(1*delta)
	if (Input.is_key_pressed(KEY_E)):
		rotate_z(-1*delta)
	if (Input.is_key_pressed(KEY_MINUS)):
		if (state==1):
			cam_size=cam_size+100*delta
			set_orthogonal(cam_size,0.01,8192)
		else:
			cam_size=cam_size+100*delta
			set_perspective(cam_size,0.01,8192)
	if (Input.is_key_pressed(KEY_0)):
		if (state==1):
			cam_size=cam_size-100*delta
			set_orthogonal(cam_size,0.01,8192)
		else:
			cam_size=cam_size-100*delta
			set_perspective(cam_size,0.01,8192)
	if (Input.is_key_pressed(KEY_R)):
		cam_size=700
		set_orthogonal(cam_size,0.01,8192)
		translation=base_pos
	if (Input.is_key_pressed(KEY_F)):
		if (state==1):
			set_perspective(cam_size,0.01,8192)
			state=state-1
		else:
			set_orthogonal(cam_size,0.01,8192)
			state=state+1
		

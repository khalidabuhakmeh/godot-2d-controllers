extends CharacterBody2D

@export var speed := 500.0
@export_range(0, 1) var floatiness := 0.025
@onready var sprite := $Sprite2D

func _physics_process(delta: float) -> void:
	var direction := Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	velocity = velocity.lerp(speed * direction, floatiness)

	# flip children to face 
	# the correct direction
	if direction.x < 0:
		sprite.flip_h = false
	elif direction.x > 0:
		sprite.flip_h = true
	
	move_and_slide()

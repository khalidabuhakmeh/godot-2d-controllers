extends CharacterBody2D

@export var speed := 100

func _physics_process(delta: float) -> void:
	var direction := Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	velocity = speed * direction
	move_and_slide()

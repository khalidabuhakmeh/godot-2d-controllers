extends CharacterBody2D

@export var rotation_speed: float = 3.0
@export var acceleration: float = 500.0  # Acceleration rate
@export var deceleration: float = 500.0  # Deceleration rate
@export var max_speed: float = 500.0 # Maximum speed

func _physics_process(delta: float) -> void:
	process_movement(delta)
	process_rotation(delta)
	move_and_slide()
	
func process_movement(delta: float) -> void:
	var target_velocity: Vector2 = Vector2.ZERO

	if Input.is_action_pressed("ui_up"):
		target_velocity = up_direction.rotated(rotation) * max_speed
	elif Input.is_action_pressed("ui_down"):
		target_velocity = up_direction.rotated(rotation + PI) * max_speed

	if target_velocity:
		velocity = velocity.move_toward(target_velocity, acceleration * delta)
	else:
		velocity = velocity.move_toward(Vector2.ZERO, deceleration * delta)

func process_rotation(delta: float) -> void:
	# only rotate when velocity is not zero
	# Normalizing the rotation speed based on forward momentum
	var normalized_speed = velocity.length() / max_speed

	if Input.is_action_pressed("ui_left"):
		rotation -= delta * rotation_speed * normalized_speed
	elif Input.is_action_pressed("ui_right"):
		rotation += delta * rotation_speed * normalized_speed

extends CharacterBody2D

@export var speed := 100.0
@export var force := 500.0
@export var cooldown_milliseconds := 500.0

var previous_jump := -10_000.0

func _physics_process(delta: float) -> void:
	
	# always falling
	velocity += get_gravity() * delta
	#always moving forward
	velocity = Vector2(speed, velocity.y)
	
	var now = Time.get_ticks_msec()
	var difference = now - previous_jump
	var can_jump = difference >= cooldown_milliseconds
	
	if can_jump and Input.is_action_just_pressed("ui_accept"):
		velocity.y = -force
		previous_jump = now
		
	move_and_slide()

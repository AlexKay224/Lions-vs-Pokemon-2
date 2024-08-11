shader_type canvas_item;

uniform vec4 current_color;

//void vertex() {
	//// Called for every vertex the material is visible on.
//}

void fragment() {
	// Called for every pixel the material is visible on.
	vec4 final = mix(texture(TEXTURE, UV), current_color, texture(TEXTURE, UV).a);
	COLOR = final;
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}

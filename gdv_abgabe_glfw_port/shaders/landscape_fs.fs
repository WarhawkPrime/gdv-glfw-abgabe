#version 330 core
out vec4 FragColor;
  

in vec3 ourColor;
in vec2 TexCoord;
in vec3 Normal;
in vec3 FragPos;

uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightDirection;
uniform vec3 viewPos;
uniform sampler2D ourTexture;


void main()
{
    
    // Ambient lighting
    float ambientStrength = 0.5;
    vec3 ambient = ambientStrength * lightColor;



    // Diffuse lighting
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightDirection);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;


    // Specular lighting
    float specularStrength = 1.0;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3  specular = specularStrength * spec * lightColor;


    vec3 result = ambient + diffuse;
    FragColor = texture(ourTexture, TexCoord) * vec4(result, 1.0f);

}
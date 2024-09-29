namespace YYMinimalApiPractice.Extentions
{
    public static class SwaggerExtention
    {
        public static IServiceCollection AddSwagger (this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}

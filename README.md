# Cache-Sample
Sample project using memory cache and Redis Cache. The project also includes a simple subscription option with Redis

To use Redis you will need to have the docker container, you can check it on [this link](https://hub.docker.com/_/redis)

To run it with docker you can execute the following command:
```
docker run -p 6379:6379 --name redis -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes redis:latest
```
* `--name`: Name of the container
* `--e REDIS_REPLICATION_MODE=master`: Set environment variables into the container. In this case we are setting that this container will be behaving as Master, in the [Master-Slave pattern](https://en.wikipedia.org/wiki/Master/slave_(technology))
* `--e ALLOW_EMPTY_PASSWORD=yes`: Set environment variables into the container. In this case we are specifying that yoyr app can connect to the database without using a password. **Important, this is not recommended in production environments**



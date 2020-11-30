let root = document.body;
let section = document.createElement('section');

section.classList.add('main');
root.append(section);

function getInputValue() {
    let city = document.getElementById('submit').value;

    fetch("http://api.weatherstack.com/current?access_key=430a1ea136ec4ef486ee0539618d560d&query=" + city + "")
        .then(response => {
            return response.json();
        })
        .then(data => {
            let info = document.createElement('div');
            info.classList.add('info');
            section.append(info);

            let details = document.createElement('div');
            details.classList.add('details');
            info.append(details);


            let title = document.createElement('p');
            let content = document.createTextNode(`Name: ${data.location.name}, ${data.location.country}`);
            title.classList.add('title');
            title.appendChild(content);
            details.append(title);

            let list = document.createElement('p');
            let items = document.createTextNode(
                `Temperature: ${data.current.temperature}°C
                 Feels like: ${data.current.feelslike}°C
                 Weather description: ${data.current.weather_descriptions[0]}

                 Wind speed: ${data.current.wind_speed}
                 Wind direction: ${data.current.wind_dir}

                 Air pressure: ${data.current.pressure}
                 Humidity: ${data.current.humidity}%

                 Cloud cover: ${data.current.cloudcover}%
                 Visibility level: ${data.current.visibility}

                 UV index: ${data.current.uv_index}

                 Latitude: ${data.location.lat}
                 Longitude: ${data.location.lon}

                 Last updated on: ${data.current.observation_time}`);
            list.classList.add('list');
            list.appendChild(items);
            details.append(list);

            let image = document.createElement('img');
            image.setAttribute('src', data.current.weather_icons[0]);
            image.setAttribute('alt', data.current.weather_descriptions[0]);
            image.setAttribute('width', '100px');
            image.setAttribute('height', '100px');
            details.append(image);
        })
}
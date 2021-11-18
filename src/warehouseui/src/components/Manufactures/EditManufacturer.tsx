import { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { Country, Manufacturer } from '../../Types/types';
import cloneDeep from 'lodash-es/cloneDeep';

import "react-datepicker/dist/react-datepicker.css";

const EditManufacturer = () => {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [model, setModel] = useState<Manufacturer>();
    const [countries, setCountries] = useState<Country[]>();
    const { manufacturerId } = useParams();
    let history = useHistory();
    
    const fetchFromServer = () => {
        fetch("http://localhost:5000/manufactures/" + manufacturerId)
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        }).then((result) => {
            setIsLoaded(true);
            setModel(result);
        },
        (error) => {
            setIsLoaded(true);
            setError(error.message);
        });
    };

    const fetchCountriesFromServer = () => {
        fetch("http://localhost:5000/countries")
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        }).then((result) => {
            setCountries(result);
        },
        (error) => {
            setIsLoaded(true);
            setError(error.message);
        });
    };
    
    useEffect(() => {
        fetchFromServer();
    }, []);


    useEffect(() => {
        fetchCountriesFromServer();
    }, [isLoaded]);

    const saveModel = () => {
        fetch("http://localhost:5000/manufactures/" + manufacturerId,
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(model)
        })
        .then((response) => {
            if (!response.ok) {
                throw new Error('Something went wrong');
            }
        }).then((result) => {
            alert('Збережено');
            history.push('/manufacturers');
        },
        (error) => {
            setIsLoaded(true);
            setError(error.message);
        });
    };

    const onCountryChanged = (countryId: string) => {
        var country = countries?.find((element) => {
            return element.id == Number(countryId);
        });
        if (country) {
            var currentModel = cloneDeep(model) as Manufacturer;
            currentModel.country = country;
            setModel(currentModel);
        }
    };

    const onNameChanged = (value: string) => {
        var currentModel = cloneDeep(model) as Manufacturer;
        currentModel.name = value;
        setModel(currentModel);
    };

    if (error) {
        return <div>Error: {error}</div>;
    } else if (!isLoaded) {
        return <div>Loading...</div>;
    } else {
        return (
            <div>
            <h4>Редагувати виробника</h4>
            <div>Назва:</div>
            <div>
                <input type="text" defaultValue={model?.name} onChange={(e) => onNameChanged(e.target.value)} />
            </div>
            <div>Країна:</div>
            <div>
                <select value={model?.country.id} onChange={(e) => onCountryChanged(e.target.value)}>
                    <option value={''}></option>
                    {countries?.map((item, index) => {     
                        return (
                            <option key={index} value={item.id}>{item.name}</option>
                        ) 
                    })}
                </select>
            </div>
            <button onClick={() => saveModel()}>Зберегти</button>
            </div>
        );
    }
}

export default EditManufacturer;
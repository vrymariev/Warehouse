import { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';


import "react-datepicker/dist/react-datepicker.css";
import cloneDeep from 'lodash-es/cloneDeep';
import { Country, GoodType, Manufacturer } from '../../Types/types';

const AddManufacturer = () => {
    const [model, setModel] = useState<Manufacturer>({} as Manufacturer);
    const [countries, setCountries] = useState<Country[]>();
    const { goodId } = useParams();
    let history = useHistory();

    const fetchCountriesFromServer = () => {
        fetch('http://localhost:5000/countries')
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((result) => {
            setCountries(result);
        }).catch((error) => {
            alert(error.message);
        });
    };
    
    useEffect(() => {
        fetchCountriesFromServer();
    }, []);

    const saveModel = () => {
        fetch("http://localhost:5000/manufactures/" + goodId,
            {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(model)
            })
            .then(
            (result) => {
                alert('Додано');
                history.push('/manufacturers');
            },
            (error) => {
                alert('помилка');
            }
        )
    };

    const onNameChanged = (value: string) => {
        var currentModel = cloneDeep(model) as Manufacturer;
        currentModel.name = value;
        setModel(currentModel);
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

    return (
        <div>
            <h4>Новий виробник</h4>
            <div>Назва:</div>
            <div>
                <input type="text" defaultValue={model?.name} onChange={(e) => onNameChanged(e.target.value)} />
            </div>

            <div>Країна:</div>
            <div>
                <select onChange={(e) => onCountryChanged(e.target.value)}>
                    <option value={''}></option>
                    {countries?.map((item, index) => {     
                        return (
                            <option key={index} value={item.id}>{item.name}</option>
                        ) 
                    })}
                </select>
            </div>
            <button onClick={() => saveModel()}>Додати</button>
        </div>
    );
}

export default AddManufacturer;
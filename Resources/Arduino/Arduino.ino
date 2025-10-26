#pragma region Properties
  const String stringEmpty = "";
  String input = stringEmpty;
#pragma endregion Properties

#pragma region Public Methods
  void setup() {
    Serial.begin(9600);

    pinMode(2, OUTPUT);
    pinMode(3, OUTPUT);
    pinMode(4, OUTPUT);
    pinMode(5, OUTPUT);
    pinMode(8, INPUT);

    digitalWrite(2, HIGH);
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
    digitalWrite(5, HIGH);
  }

  void loop() {

    if (PuertoSerieLibre())
    {
      input = Serial.readString();
      input.trim();

      int inst = input.toInt();

      switch (inst) {
        case -1 : Reset(); break;
        case 0 : GetStates(); break;
        case 1 : TurnFansCase(LOW); Serial.println("false"); break;
        case 2 : TurnLightCase(LOW); Serial.println("false"); break;
        case 3 : TurnScreenCase(LOW); Serial.println("false"); break;
        case 4 : TurnFansCase(HIGH); Serial.println("true"); break;
        case 5 : TurnLightCase(HIGH); Serial.println("true"); break;
        case 6 : TurnScreenCase(HIGH); Serial.println("true"); break;
        case 7 : Serial.println(GetState(5)); break;
        case 8 : Serial.println(GetState(4)); break;
        case 9 : Serial.println(GetState(3)); break;     
        case 10 : TurnAll(LOW); Serial.println("false"); break;
        case 11 : TurnAll(HIGH); Serial.println("true"); break;
      }
    }
  }
#pragma endregion Public Methods

#pragma region Private Methods

  #pragma region Relays
    void TurnAll(int state){
      TurnLightCase(state);
      TurnFansCase(state);
      TurnScreenCase(state);
    }
  
    void TurnLightRoom(int state){
      if(digitalRead(8) != state)
      {
        ChangeState(2);
      }
    }

    void TurnLightCase(int state){
      if(digitalRead(4) != state)
      {
        ChangeState(4, state);
      }
    }

    void TurnFansCase(int state){
      if(digitalRead(5) != state)
      {
        ChangeState(5, state);
      }
    }

    void TurnScreenCase(int state){
      if(digitalRead(3) != state)
      {
        ChangeState(3, state);
      }
    }
  #pragma endregion Relays

  #pragma region Setters
    void(* resetFunc) (void) = 0;

    void Reset()
    {
      Serial.println("Arduino reiniciado");

      delay(100);
      resetFunc();
    }

    void DigitalPortOn(int digitalPort)
    {
      digitalWrite(digitalPort, HIGH);
    }

    void DigitalPortOff(int digitalPort)
    {
      digitalWrite(digitalPort, LOW);
    }

    void ChangeState(int port, int state){
      if(state == HIGH){
        DigitalPortOn(port);
      }
      else
      {
        DigitalPortOff(port);
      }
    }

    void ChangeState(int port){
      ChangeState(port, digitalRead(port));
    }
  #pragma endregion Setters

  #pragma region Getters
    String GetState(int port)
    {
        if(port < 0)
        {
          port = port * (-1);

          return addResult(port, LOW);
        }
        else
        {
          return addResult(port, HIGH);
        }
    }
  
    void GetStates() 
    {
      String result = "";

      int ports [3]= {3, 4, 5};
      int port;

      for(int i = 0; i < 3; i++)
      {    
        if( i > 0)
        {
          result += ",";
        }

        result += GetState(ports[i]);
      }
      
      Serial.println(result);
    }

    String addResult(int port, int state)
    {
      if(digitalRead(port) == state)
      {
        return "true";
      }
      else
      {
        return "false";
      }
    }

    bool PuertoSerieLibre() 
    {
      return Serial.available() > 0;
    }
  #pragma endregion Getters
#pragma endregion Private Methods

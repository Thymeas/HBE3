using UnityEngine;

public class ExamplePlayerController : MonoBehaviour 
{
	private Rigidbody _mRigidbody;

	public string HorizontalAxis;
	public string VerticalAxis;
	public string JumpButton;

	private float _inputHorizontal;
	private float _inputVertical;

	void Awake()
	{
		_mRigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//_inputHorizontal = SimpleInput.GetAxis( HorizontalAxis );
		//_inputVertical = SimpleInput.GetAxis( VerticalAxis );

		//transform.Rotate( 0f, _inputHorizontal * 2.5f, 0f, Space.World );

		//if( SimpleInput.GetButtonDown( JumpButton ) && IsGrounded() )
		//	_mRigidbody.AddForce( 0f, 1.0f, 0f, ForceMode.Impulse );
	}

	void FixedUpdate()
	{
		_mRigidbody.AddRelativeForce( new Vector3( 0f, 0f, _inputVertical ) * 25.0f );
	}

	//bool IsGrounded()
	//{
	//	return Physics.Raycast( transform.position, Vector3.down, 1.75f );
	//}
}
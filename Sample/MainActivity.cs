using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using Com.Dinuscxj.Ellipsize;
using Java.Lang;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@mipmap/icon", Theme="@style/AppTheme")]
    public class MainActivity : AppCompatActivity, ITextWatcher
    {
        private EllipsizeTextView mTvEllipsize0;
        private EllipsizeTextView mTvEllipsize1;
        private EllipsizeTextView mTvEllipsize2;
        private EllipsizeTextView mTvEllipsize3;
        private EllipsizeTextView mTvEllipsize4;
        private EllipsizeTextView mTvEllipsize5;
        private EllipsizeTextView mTvEllipsize6;
        private EllipsizeTextView mTvEllipsize7;

        private EditText mEtInput;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            mTvEllipsize0 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize0);
            mTvEllipsize1 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize1);
            mTvEllipsize2 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize2);
            mTvEllipsize3 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize3);
            mTvEllipsize4 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize4);
            mTvEllipsize5 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize5);
            mTvEllipsize6 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize6);
            mTvEllipsize7 = FindViewById<EllipsizeTextView>(Resource.Id.tv_ellipsize7);

            mEtInput = FindViewById<EditText>(Resource.Id.input_text);

            setUpTvEllipsize0();
            setUpTvEllipsize1();
            setUpTvEllipsize2();
            setUpTvEllipsize3();
            setUpTvEllipsize4();
            setUpTvEllipsize5();
            setUpTvEllipsize6();
            setUpTvEllipsize7();
        }

        private void setUpTvEllipsize0()
        {
            SpannableString moreText = new SpannableString("...");
            moreText.SetSpan(new ForegroundColorSpan(Color.Red), 0, moreText.Length(), SpanTypes.ExclusiveExclusive);

            mTvEllipsize0.SetEllipsizeText(moreText, 0);
            mTvEllipsize0.SetText(Resource.String.long_text);
        }

        private void setUpTvEllipsize1()
        {
            SpannableString moreText = new SpannableString("...");
            moreText.SetSpan(new ForegroundColorSpan(Color.Magenta), 0, moreText.Length(), SpanTypes.ExclusiveExclusive);

            mTvEllipsize1.SetEllipsizeText(moreText, 0);
            mTvEllipsize1.SetText(Resource.String.long_text);
        }

        private void setUpTvEllipsize2()
        {
            SpannableString moreText = new SpannableString("***");
            moreText.SetSpan(new ForegroundColorSpan(Color.Cyan), 0, moreText.Length(), SpanTypes.ExclusiveExclusive);

            mTvEllipsize2.SetEllipsizeText(moreText, 0);
            mTvEllipsize2.SetText(Resource.String.long_text);
        }

        private void setUpTvEllipsize3()
        {
            SpannableString moreText = new SpannableString("***");
            moreText.SetSpan(new ForegroundColorSpan(Color.Green), 0, moreText.Length(), SpanTypes.ExclusiveExclusive);

            mTvEllipsize3.SetEllipsizeText(moreText, 8);
            mTvEllipsize3.SetText(Resource.String.long_text);
        }

        private void setUpTvEllipsize4()
        {
            string timeText = " 1 minute ago";
            SpannableString timeLongText = new SpannableString(GetString(Resource.String.long_text) + timeText);
            timeLongText.SetSpan(new TextAppearanceSpan(this, Resource.Style.time_style),
                                 timeLongText.Length() - timeText.Length, timeLongText.Length(), SpanTypes.ExclusiveExclusive);

            SpannableString moreText = new SpannableString("...more");

            moreText.SetSpan(new EllipsizeSpan(mTvEllipsize4, timeLongText), 3, moreText.Length(), SpanTypes.ExclusiveExclusive);
                                 
            moreText.SetSpan(new TextAppearanceSpan(this, Resource.Style.link_style), 3, moreText.Length(), SpanTypes.ExclusiveExclusive);

            mTvEllipsize4.MovementMethod = LinkMovementMethod.Instance;
            mTvEllipsize4.SetText(timeLongText, TextView.BufferType.Normal);
            mTvEllipsize4.SetEllipsizeText(moreText, timeText.Length);
        }

        private void setUpTvEllipsize5()
        {
            var colors = new Color[] { Color.Gray, Color.Magenta, Color.Cyan, Color.Green, Color.Yellow, Color.Red, Color.Blue };

            SpannableString longNumberText = new SpannableString(GetString(Resource.String.long_number_text));
            for (int i = 0; i < longNumberText.Length(); i += 10)
            {
                longNumberText.SetSpan(new ForegroundColorSpan(colors[i / 10 % colors.Length]),
                        i, i + 10, SpanTypes.ExclusiveExclusive);
            }
            mTvEllipsize5.SetText(longNumberText, TextView.BufferType.Normal);
        }

        private void setUpTvEllipsize6()
        {
            SpannableString moreText = new SpannableString("...");
            moreText.SetSpan(new ForegroundColorSpan(Color.Magenta), 0, moreText.Length(), SpanTypes.ExclusiveExclusive);

            mTvEllipsize6.SetEllipsizeText(moreText, 0);
            mTvEllipsize6.SetText(Resource.String.long_text);
        }

        private void setUpTvEllipsize7()
        {
            mEtInput.AddTextChangedListener(this);
        }

        public void AfterTextChanged(IEditable s)
        {
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            mTvEllipsize7.SetText(s, TextView.BufferType.Normal);
        }
    }

    public class EllipsizeSpan : ClickableSpan
    {
        private EllipsizeTextView mTvEllipsize;
        private SpannableString timeLongText;

        public EllipsizeSpan(EllipsizeTextView textView, SpannableString text) : base()
        {
            mTvEllipsize = textView;
            timeLongText = text;
        }

        public override void OnClick(View widget)
        {
            mTvEllipsize.SetText(timeLongText, TextView.BufferType.Normal);
            mTvEllipsize.SetMaxLines(Integer.MaxValue);
        }

        public override void UpdateDrawState(TextPaint ds)
        {
            base.UpdateDrawState(ds);
            ds.UnderlineText = false;
        }
    }
}


